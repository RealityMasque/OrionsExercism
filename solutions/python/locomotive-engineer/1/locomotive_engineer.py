"""Functions which helps the locomotive engineer to keep track of the train."""


def get_list_of_wagons(*args):
    """Return a list of wagons.

    :param: arbitrary number of wagons.
    :return: list - list of wagons.
    """
    *wagons, = args
    return wagons


def fix_list_of_wagons(each_wagons_id, missing_wagons):
    """Fix the list of wagons.

    :param each_wagons_id: list - the list of wagons.
    :param missing_wagons: list - the list of missing wagons.
    :return: list - list of wagons.
    """
    #move 1st & 2nd ids in each_wagons_id to end of each_wagons_id
    first, second, *the_rest = each_wagons_id
    first_two = [first, second]
    each_wagons_id = *the_rest, *first_two
    
    #put missing_wagons after 1st in each_wagons_id
    first, *the_rest = each_wagons_id
    first = [first]
    *wagons, = *first, *missing_wagons, *the_rest
    
    return wagons


def add_missing_stops(route, **kwargs):
    """Add missing stops to route dict.

    :param route: dict - the dict of routing information.
    :param: arbitrary number of stops.
    :return: dict - updated route dictionary.
    """
    *stops, = kwargs.values()
    route["stops"] = stops
    return route


def extend_route_information(route, more_route_information):
    """Extend route information with more_route_information.

    :param route: dict - the route information.
    :param more_route_information: dict -  extra route information.
    :return: dict - extended route information.
    """
    extended_route_information = {**route, **more_route_information}
    return extended_route_information


def fix_wagon_depot(wagons_rows):
    """Fix the list of rows of wagons.

    :param wagons_rows: list[list[tuple]] - the list of rows of wagons.
    :return: list[list[tuple]] - list of rows of wagons.
    """
    return [list(col) for col in zip(*wagons_rows)]
