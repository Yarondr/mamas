from mpmath import mp


def reverse_n_pi_digits(n: int):
    mp.dps = n + 1
    return (str(mp.pi)[2:2 + n])[::-1]
