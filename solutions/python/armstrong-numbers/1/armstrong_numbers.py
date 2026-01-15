def is_armstrong_number(number):
    num = str(number)
    powered_digit_sum = 0
    for index in range(len(num)):
        powered_digit_sum += int(num[index]) ** len(num)
    return number == powered_digit_sum