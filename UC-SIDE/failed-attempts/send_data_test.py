# Dashboard for car simulator Project
# COM Testing program
# by Luis Felipe La Rotta
# 2024-28-13

import serial


def main():
    
    s = serial.Serial(port="COM15", baudrate=115200, parity=serial.PARITY_EVEN, stopbits=serial.STOPBITS_ONE, timeout=1)
    s.flush()
    
    json_message = '{"rpm": 0, "speed": 0, "gear": 2, "gas": 30.0}' + '\r\n'

    s.write(json_message.encode())

    mes = s.read_until().strip()   

    print("received: " + mes.decode())

    s.close()  

if __name__ == "__main__":
    main()
