#include <iostream>

#include "network/server.h"
#include "network/client.h"

#include <raspicam/raspicam.h>

using namespace std;
using namespace core::network;
using namespace raspicam;

// 1B typ ramki
// 1B typ operacji


enum FrameType
{
    FT_Undefined = 0,
    FT_Camera = 1,
//    FT_Led,
//    FT_Gyro,
//    FT_Temperature,
    FT_Shutdown // zatrzymuje serwer
};

enum CameraOperationType
{
    COT_Undefined = 0,
    COT_Resize = 1,
    COT_Enable,
    COT_Disable,
    COT_GetImage
};

RaspiCam camera;
uint8_t buffer[256];

void freeClient(Socket *client);
int makeClient(Socket *client);

int main()
{
    Server server;

    if(server.run(26, 5000))
    {
        while(true)
        {
            Socket *client = server.accept();

            if(client == NULL)
                continue;

            std::cout << "Client joined." << std::endl;

            buffer[0] = (camera.isOpened() ? 1 : 0);

            *(uint16_t*)(buffer + 1) = (uint16_t)camera.getWidth();
            *(uint16_t*)(buffer + 3) = (uint16_t)camera.getHeight();

            if(client->write(buffer, 5))
            {
                while(true)
                {
                    int result = makeClient(client);

                    if( result == 1 )
                        continue;

                    freeClient(client);

                    std::cout << "Client left." << std::endl;

                    if(result == 2)
                    {
                        server.stop();

						//TODO: camera close operation
						
                        return 0;
                    }
                    else
                        break;
                }
            }
        }
		
		//TODO: camera close operation
    }

    return 1;
}

void freeClient(Socket *client)
{
    client->close();

    delete client;
}

bool resizeCamera(Socket *client)
{
    if(camera.isOpened())
        buffer[0] = 0; // failed

    else
    {
        if(!client->read(buffer, 4))
            return false;

        uint16_t width = *(uint16_t*)buffer;
        uint16_t height = *(uint16_t*)(buffer + 2);

        camera.setWidth(width);
        camera.setHeight(height);

        buffer[0] = 1; // success

        std::cout << "Camera resize (" << width << "x" << height << ")." << std::endl;
    }

    return client->write(buffer, 1);
}

bool enableCamera(Socket *client)
{
    if(camera.open())
    {
        sleep(3);
        buffer[0] = 1; // success

        std::cout << "Camera enabled." << std::endl;
    }
    else
        buffer[0] = 0; // failed

    return client->write(buffer, 1);
}

bool disableCamera(Socket *client)
{
    camera.release();
    buffer[0] = 1; // success

    std::cout << "Camera disabled." << std::endl;

    return client->write(buffer, 1);
}

bool captureImage(Socket *client)
{
    if(camera.isOpened() && camera.grab())
    {
        size_t imageSize = camera.getImageBufferSize();
        uint8_t *data = camera.getImageBufferData();

        buffer[0] = 1; // success
        *(uint16_t*)(buffer + 1) = (uint16_t)camera.getWidth();
        *(uint16_t*)(buffer + 3) = (uint16_t)camera.getHeight();

        std::cout << "Capture camera (" << camera.getWidth() << "x" << camera.getHeight() << ")." << std::endl;

        return client->write(buffer, 5) && client->write(data, imageSize);
    }
    else
    {
        buffer[0] = 0; // failed

        return client->write(buffer, 1);
    }
}

bool makeCamera(Socket *client)
{
    if(client->read(buffer, 1))
    {
        switch(*buffer)
        {
            case COT_Resize:
                return resizeCamera(client);

            case COT_Enable:
                return enableCamera(client);

            case COT_Disable:
                return disableCamera(client);

            case COT_GetImage:
                return captureImage(client);
        }
    }

    return false;
}

int makeClient(Socket *client)
{
    if(client->read(buffer, 1))
    {
        switch(*buffer)
        {
            case FT_Camera:
                return makeCamera(client) ? 1 : 0;

            case FT_Shutdown:
                return 2;

            default:
                return 0;
        }
    }
    else
        return 0;
}
