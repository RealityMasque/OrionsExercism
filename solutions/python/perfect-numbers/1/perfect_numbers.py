import math

def get_factors(number):
    factors = []
    max = int(math.sqrt(number))
    for potential in range(1, max + 1):
        if number % potential == 0:
            factors.append(potential)
            factors.append(number / potential)
    deduped = set(factors)
    deduped.discard(number)
    return list(deduped)

def classify(number):
    """ A perfect number equals the sum of its positive divisors.

    :param number: int a positive integer
    :return: str the classification of the input integer
    """
    if number <= 0:
        raise ValueError("Classification is only possible for positive integers.")

    factors = get_factors(number)
    aliquot_sum = sum(factors)

    if number == aliquot_sum:
        return "perfect"

    if number < aliquot_sum:
        return "abundant"

    return "deficient"
