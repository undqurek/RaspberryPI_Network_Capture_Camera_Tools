#include "socket.h"


namespace core { namespace network
{
    Socket::Socket()
    {
#if SYSTEM == LINUX
        this->_descriptor = -1;
#endif // LINUX

#if SYSTEM == WINDOWS
        this->_descriptor = INVALID_SOCKET;
#endif // WINDOWS

		this->_readBytes = 0;
        this->_writtenBytes = 0;

		this->_ip = NULL;
    }

#if SYSTEM == LINUX
    Socket::Socket(int descriptor, char *_ip)
    {
        this->_descriptor = descriptor;

        this->_readBytes = 0;
        this->_writtenBytes = 0;

        this->_ip = _ip;
    }
#endif // LINUX

#if SYSTEM == WINDOWS
    Socket::Socket(::SOCKET descriptor, char *_ip)
	{
        this->_descriptor = descriptor;

		this->_readBytes = 0;
        this->_writtenBytes = 0;

		this->_ip = _ip;
	}
#endif // WINDOWS

    Socket::~Socket()
    {
        this->close();
    }

    const char *Socket::__getIP()
    {
        return this->_ip;
    }

    bool Socket::close()
    {
        if(this->isOpen())
        {
            //TODO: poprawne zwalnainie pamieci
//            Cleaner::deleteArray(this->_ip);

#if SYSTEM == LINUX
            if(::shutdown(this->_descriptor, SHUT_RDWR) == 0
                && ::close(this->_descriptor) == 0)
            {
                this->_descriptor = -1;

                this->_readBytes = 0;
                this->_writtenBytes = 0;

                return true;
            }
#endif // LINUX

#if SYSTEM == WINDOWS
            if(::shutdown(this->_descriptor, SD_BOTH) == 0
                && ::closesocket(this->_descriptor) == 0)
            {
                this->_descriptor = INVALID_SOCKET;

                this->_readBytes = 0;
                this->_writtenBytes = 0;

                return true;
            }
#endif // WINDOWS
        }

        return false;
    }

    bool Socket::isOpen()
    {
#if SYSTEM == LINUX
        return this->_descriptor != -1;
#endif // LINUX

#if SYSTEM == WINDOWS
        return this->_descriptor != INVALID_SOCKET;
#endif // WINDOWS
    }

    bool Socket::read(const uint8_t *buffer, uint32_t length)
    {
        if(this->isOpen())
        {
            while(length > 0)
            {
#if SYSTEM == LINUX
                int tmp = ::recv(this->_descriptor, (void *)buffer, length, MSG_WAITALL);

                if(tmp == -1)
                    return false;
#endif

#if SYSTEM == WINDOWS
                //TODO: rozwiazac problem MSG_WAITALL i blocking==false
                int tmp = ::recv(this->_descriptor, (char *)buffer, length, MSG_WAITALL);

                if(tmp == SOCKET_ERROR)
                    return false;
#endif
                if(tmp == 0)
                    return false;

                buffer += tmp;
                length -= tmp;

                this->_readBytes += tmp;
            }

            return true;
        }

        return false;
    }

    bool Socket::write(const uint8_t *buffer, uint32_t length)
    {
        if(this->isOpen())
        {
            while(length > 0)
            {
#if SYSTEM == LINUX
                int tmp = ::send(this->_descriptor, buffer, length, 0);

                if(tmp == -1)
                    return false;
#endif

#if SYSTEM == WINDOWS
                int tmp = ::send(this->_descriptor, (char *)buffer, length, 0);

                if(tmp == SOCKET_ERROR)
                    return false;
#endif
                buffer += tmp;
                length -= tmp;

                this->_writtenBytes += tmp;
            }

            return true;
        }

        return false;
    }

    uint32_t Socket::available()
    {
        if(this->isOpen())
        {
#if SYSTEM == LINUX
            int count = 0;

            if (::ioctl(this->_descriptor, FIONREAD, &count) == -1)
                return 0;
#endif

#if SYSTEM == WINDOWS
            u_long count = 0;

            if (::ioctlsocket(this->_descriptor, FIONREAD, &count) == SOCKET_ERROR)
                return 0;
#endif

            return (uint32_t)count;
        }

        return 0;
    }
}}
