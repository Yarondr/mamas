def is_sorted_polyndrom(string: str):
    """
    Returns a boolean that indicates if a string is sorted palindrome
    :param string:
    :return: Is a string a sorted palindrome (bool)
    """
    is_even = len(string) % 2 == 0
    part_one = string[0:len(string) // 2]
    part_two = string[len(string) // 2 if is_even else (len(string) // 2) + 1:]

    if part_one != part_two[::-1]:
        return False

    direction = None
    for index, letter in enumerate(part_one[1:]):
        dir = ord(letter) - ord(part_one[index])
        if dir == 0:
            return False
        if index == 0:
            direction = dir
        elif direction != dir:
            return False

    if not is_even:
        if chr(ord(part_one[-1]) + direction) != string[len(string) // 2]:
            return False

    return True
