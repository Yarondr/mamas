import math


def num_len(number: int) -> int:
    """Returns the length of a number"""
    return math.ceil(math.log(number, 10))
