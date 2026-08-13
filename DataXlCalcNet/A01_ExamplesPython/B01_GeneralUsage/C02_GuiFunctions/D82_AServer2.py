import socket
#from xlcalcnet import gui


def call_server(SnippetToSend):
    DataReceived = 'No Server'
    try:
        host = socket.gethostname() 
        port = 11958  # socket server port number
        client_socket = socket.socket()  # instantiate
        client_socket.connect((host, port))  # connect to the server
        client_socket.send(SnippetToSend.encode())  # send message
        DataReceived = client_socket.recv(1024).decode()  # receive response
    
    except Exception:
        import traceback
        DataReceived =traceback.format_exc()

    client_socket.close()
    return DataReceived


try:
#    gui.socketserver()

#    SnippetToSend = "mpm.dps=20; result = mpm.exp(15 + 4)"
#    SnippetToSend = "result = mpm.cos(15 + 4)"
#    SnippetToSend = "result = 'üöä'"
    SnippetToSend = "mpm.dps=80; x = mpm.t(5); y = mpm.sqrt(x); z = x + y; result = str(z)+ 'ÖüÄß'"

    DataReceived = call_server(SnippetToSend)
    print('Received from server: ' + DataReceived)


except Exception:
    import traceback
    print(traceback.format_exc())


