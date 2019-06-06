#g++ -L raspicam  -I . -I /usr/local/include/raspicam -o server basic/preprocesor.h network/client.h network/server.h network/socket.h network/client.cpp network/server.cpp network/socket.cpp main.cpp

#g++ -o server -I"." -I"/usr/local/include" -L"/opt/vc/lib/" -lraspicam -lmmal -lmmal_core -lmmal_util basic/preprocesor.h network/client.h network/server.h network/socket.h network/client.cpp network/server.cpp network/socket.cpp main.cpp




g++ \
	-o ../server \
	-I".." \
	-I"/usr/local/include/" \
	-L"/usr/local/lib/" \
	-l"raspicam" \
	-l"pthread" \
	../basic/preprocesor.h \
	../network/client.h \
	../network/server.h \
	../network/socket.h \
	../network/client.cpp \
	../network/server.cpp \
	../network/socket.cpp \
	../main.cpp
