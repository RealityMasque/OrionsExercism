import math

OUTER_RADIUS = 10
MIDDLE_RADIUS = 5
INNER_RADIUS = 1

NO_SCORE = 0
OUTER_SCORE = 1
MIDDLE_SCORE = 5
INNER_SCORE = 10

def score(x, y):
    distance = math.sqrt(x * x + y * y)

    if distance > OUTER_RADIUS:
        return NO_SCORE

    if distance > MIDDLE_RADIUS:
        return OUTER_SCORE

    if distance > INNER_RADIUS:
        return MIDDLE_SCORE

    return INNER_SCORE
