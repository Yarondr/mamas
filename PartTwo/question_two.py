def pythagorean_triplet_by_sum(sum: int) -> None:
    """
    Use the: square(a)+square(b)=square(c) equation, and the: a+b+c=n equation (when n=sum)
    To find these equations: b=(n*n-2*n*a)/(2*n-2*a), and: c=n-b-a
    With these equations, we can find the pythagorean triplets and print them

    :param sum: Natural number
    """

    for a in range(1, sum):
        b = int((sum * sum - 2 * sum * a) / (2 * sum - 2 * a))
        c = sum - a - b

        if a * a + b * b == c * c and a < b < c:
            print(f"{a} < {b} < {c}")
