def all_sides_have_length(sides):
    return sides[0] != 0 and sides[1] != 0 and sides[2] != 0


def sides_define_triangle(sides):
    if sides[0] + sides[1] < sides[2]:
        return False
    if sides[0] + sides[2] < sides[1]:
        return False
    if sides[1] + sides[2] < sides[0]:
        return False
    return True


def equilateral(sides):
    if not all_sides_have_length(sides):
        return False
    if not sides_define_triangle(sides):
        return False
    return sides[0] == sides[1] == sides[2]


def isosceles(sides):
    if not all_sides_have_length(sides):
        return False
    if not sides_define_triangle(sides):
        return False
    if equilateral(sides):
        return True
    return len(set(sides)) == 2


def scalene(sides):
    if not all_sides_have_length(sides):
        return False
    if not sides_define_triangle(sides):
        return False
    if isosceles(sides):
        return False
    return sides[0] != sides[1] != sides[2]
