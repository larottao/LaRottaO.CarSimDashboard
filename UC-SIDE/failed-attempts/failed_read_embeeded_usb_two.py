import select
import sys

# Setup poll to read USB port
poll_object = select.poll()
poll_object.register(sys.stdin, 1)

while True:
    # Check USB input
    if poll_object.poll(0):
       # Read as character
       ch = sys.stdin.read(1)
       print(ch, "hello from the pico")