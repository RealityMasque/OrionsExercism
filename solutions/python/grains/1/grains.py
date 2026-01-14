def square(number):
    if number < 1 or number > 64:
        raise ValueError("square must be between 1 and 64")
    if number == 1:
        return 1
    else:
        grains = 1
        for counter in range(2, number + 1):
            grains *= 2
        return grains


def total():
    grains = 0
    for counter in range(1, 65):
        grains += square(counter)
    return grains
