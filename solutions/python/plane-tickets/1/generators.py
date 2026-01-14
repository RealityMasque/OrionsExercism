"""Functions to automate Conda airlines ticketing system."""

EXCLUDED_ROW_NUM = 13

def generate_seat_letters(number):
    """Generate a series of letters for airline seats.

    :param number: int - total number of seat letters to be generated.
    :return: generator - generator that yields seat letters.

    Seat letters are generated from A to D.
    After D it should start again with A.

    Example: A, B, C, D
    """
    seat_letters = ['A', 'B', 'C', 'D']
    letter_count = len(seat_letters)
    counter = 0
    while counter < number:
        index = counter % letter_count
        yield seat_letters[index]
        counter += 1


def generate_seats(number):
    """Generate a series of identifiers for airline seats.

    :param number: int - total number of seats to be generated.
    :return: generator - generator that yields seat numbers.

    A seat number consists of the row number and the seat letter.

    There is no row 13.
    Each row has 4 seats.

    Seats should be sorted from low to high.

    Example: 3C, 3D, 4A, 4B
    """
    seat_letters = ['A', 'B', 'C', 'D']
    letter_count = len(seat_letters)
    for counter in range(number):
        row_num = int(counter / letter_count) + 1
        if row_num >= EXCLUDED_ROW_NUM:
            row_num += 1
        letter_index = counter % letter_count
        letter = seat_letters[letter_index]
        seat_id = str(row_num) + letter
        yield seat_id
    

def assign_seats(passengers):
    """Assign seats to passengers.

    :param passengers: list[str] - a list of strings containing names of passengers.
    :return: dict - with the names of the passengers as keys and seat numbers as values.

    Example output: {"Adele": "1A", "Björk": "1B"}
    """
    passenger_count = len(passengers)
    passenger_index = 0
    assigned_seats = {}
    for seat in generate_seats(passenger_count):
        passenger = passengers[passenger_index]
        assigned_seats[passenger] = seat
        passenger_index += 1
    return assigned_seats

def generate_codes(seat_numbers, flight_id):
    """Generate codes for a ticket.

    :param seat_numbers: list[str] - list of seat numbers.
    :param flight_id: str - string containing the flight identifier.
    :return: generator - generator that yields 12 character long ticket codes.
    """
    for seat_number in seat_numbers:
        yield (seat_number + flight_id).ljust(12, '0')
