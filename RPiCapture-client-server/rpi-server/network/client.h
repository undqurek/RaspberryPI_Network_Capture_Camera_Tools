#ifndef CLIENT_H
#define CLIENT_H

#include <stdint.h>

#include "socket.h"


namespace core { namespace network
{
    class Client
        : public Socket
    {
    private:
        bool _blocking; // blokujace sockety
        uint16_t _port;

    public:
        Client(bool _blocking = true);
        virtual ~Client();

        // Nawiazuje polaczenie ze wskazanym adresem.
        //
        bool connect(uint32_t ipv4, uint16_t port);

        bool connect(const char *ipv4, uint16_t port);

        // Zamyka polaczenie.
        //
        bool close();
    };
}}

#endif // CLIENT_H
