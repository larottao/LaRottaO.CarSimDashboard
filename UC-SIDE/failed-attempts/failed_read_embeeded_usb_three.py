import select
import sys

while True:
    if select.select([sys.stdin], [], [], 0)[0]:
        ch = sys.stdin.readline()
        print("hello from the pico")