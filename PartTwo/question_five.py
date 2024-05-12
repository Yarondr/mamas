from mpmath import mp


def reverse_n_pi_digits(n: int) -> str:
    """
    Returns the amount of the given digits in pi from the start, but in reverse.
    :param n: the amount if digits
    """
    mp.dps = n + 1
    return (str(mp.pi)[2:2 + n])[::-1]
