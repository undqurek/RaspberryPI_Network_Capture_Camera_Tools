TARGET = core
VERSION = 1.0.0.0

QT -= core gui
#TEMPLATE = app
#TEMPLATE = lib
CONFIG += console

#DEFINES += CORE_LIBRARY

#CONFIG += thread

#LIBS += -L"$$_PRO_FILE_PWD_/libs/windows/x86/" -l"Ws2_32"
#LIBS += -L"$$_PRO_FILE_PWD_/../core-build-desktop/debug/" -l"core"
LIBS += -L"$$_PRO_FILE_PWD_/libs/windows/x86-x64/" -l"Ws2_32"

#LIBS += -l"socket" -l"nsl"

HEADERS += \
    basic/preprocesor.h \
    network/socket.h \
    network/server.h \
    network/client.h


SOURCES += \
    main.cpp \
    network/socket.cpp \
    network/server.cpp \
    network/client.cpp

