import matplotlib.pyplot as plt
import numpy as np
from scipy.stats import pearsonr


def get_numbers() -> None:
    """
    Gets numbers from the user (until the user input "-1") then prints the following data:
    average number, amount of positive numbers, the sorted list of the numbers and the pearson correlation coefficient.
    Also, it shows a graph of the inputted numbers by the input order.
    """
    numbers = []

    number = input("Please enter a number: ")
    while number != "-1":
        if number.lstrip('-').isdigit():
            numbers.append(int(number))
            print(number)

        number = input("Please enter a number: ")

    positives = 0
    for n in numbers:
        if n > 0:
            positives += 1

    print(f"Average number: {sum(numbers) / len(numbers)}")
    print(f"Amount of positive numbers: {positives}")
    print(f"Sorted array: {sorted(numbers)}")

    x_axis = np.array([*range(1, len(numbers) + 1)])
    y_axis = np.array(numbers)
    print(f"Pearson correlation coefficient: {pearsonr(x_axis, y_axis).statistic}")

    plt.plot(x_axis, y_axis, 'o')
    plt.show()
