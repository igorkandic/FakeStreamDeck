import time
import usb_hid
from adafruit_hid.keycode import Keycode
from adafruit_hid.keyboard import Keyboard
import board
import digitalio


btn1_pin = board.GP3
btn2_pin = board.GP5
btn3_pin = board.GP7
btn4_pin = board.GP9
btn5_pin = board.GP11
btn6_pin = board.GP13
btn7_pin = board.GP18
btn8_pin = board.GP20
btn9_pin = board.GP22

btn1 = digitalio.DigitalInOut(btn1_pin)
btn1.direction = digitalio.Direction.INPUT
btn1.pull = digitalio.Pull.DOWN

btn2 = digitalio.DigitalInOut(btn2_pin)
btn2.direction = digitalio.Direction.INPUT
btn2.pull = digitalio.Pull.DOWN

btn3 = digitalio.DigitalInOut(btn3_pin)
btn3.direction = digitalio.Direction.INPUT
btn3.pull = digitalio.Pull.DOWN

btn4 = digitalio.DigitalInOut(btn4_pin)
btn4.direction = digitalio.Direction.INPUT
btn4.pull = digitalio.Pull.DOWN

btn5 = digitalio.DigitalInOut(btn5_pin)
btn5.direction = digitalio.Direction.INPUT
btn5.pull = digitalio.Pull.DOWN

btn6 = digitalio.DigitalInOut(btn6_pin)
btn6.direction = digitalio.Direction.INPUT
btn6.pull = digitalio.Pull.DOWN

btn7 = digitalio.DigitalInOut(btn7_pin)
btn7.direction = digitalio.Direction.INPUT
btn7.pull = digitalio.Pull.DOWN

btn8 = digitalio.DigitalInOut(btn8_pin)
btn8.direction = digitalio.Direction.INPUT
btn8.pull = digitalio.Pull.DOWN

btn9 = digitalio.DigitalInOut(btn9_pin)
btn9.direction = digitalio.Direction.INPUT
btn9.pull = digitalio.Pull.DOWN

keyboard = Keyboard(usb_hid.devices)

while True:
    if btn1.value:
        keyboard.press(Keycode.F13)
    else:
        keyboard.release(Keycode.F13)
    # time.sleep(0.01)
    if btn2.value:
        keyboard.press(Keycode.F14)
    else:
        keyboard.release(Keycode.F14)
    # time.sleep(0.01)
    if btn3.value:
        keyboard.press(Keycode.F15)
    else:
        keyboard.release(Keycode.F15)
    # time.sleep(0.01)
    if btn4.value:
        keyboard.press(Keycode.F16)
    else:
        keyboard.release(Keycode.F16)
    # time.sleep(0.01)
    if btn5.value:
        keyboard.press(Keycode.F17)
    else:
        keyboard.release(Keycode.F17)
    # time.sleep(0.01)
    if btn6.value:
        keyboard.press(Keycode.F18)
    else:
        keyboard.release(Keycode.F18)
    # time.sleep(0.01)
    if btn7.value:
        keyboard.press(Keycode.F19)
    else:
        keyboard.release(Keycode.F19)
    # time.sleep(0.01)
    if btn8.value:
        keyboard.press(111)
    else:
        keyboard.release(111)
    # time.sleep(0.01)
    if btn9.value:
        keyboard.press(112)
    else:
        keyboard.release(112)
    time.sleep(0.01)

