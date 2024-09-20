import sys

def read_utf8_message():
    message = ""
    while True:
        char = sys.stdin.read(1)  # Read one character at a time
        if char == '\n':  # Check for newline character
            break
        message += char
    return message

TEXT_WAITING_FOR_MESSAGE = "Waiting for message..."

def main():
    
    print("Console: " + TEXT_WAITING_FOR_MESSAGE)
    sys.stdout.write(TEXT_WAITING_FOR_MESSAGE + "\n")
    
    while True:       
        
        received_message = read_utf8_message()
        
        if(received_message):
            
            print("Console: " + received_message)
            
            # Echo the received message back            
            sys.stdout.write(received_message + "\n")
             
            print("Console: " + TEXT_WAITING_FOR_MESSAGE)
            sys.stdout.write(TEXT_WAITING_FOR_MESSAGE + "\n")

try:
    main()
except KeyboardInterrupt:
    print("Program interrupted.")
