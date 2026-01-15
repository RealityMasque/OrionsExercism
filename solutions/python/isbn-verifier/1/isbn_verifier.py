import re

CHECK_CHARACTER = 'X'
INVALID_LETTERS = ['A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','Y','Z']
MULTIPLIER_BASE = 10
CHECK_CHARACTER_VALUE = 10
ISBN10_CHARACTER_LENGTH = 10
CHECKCUM_MOD_VALUE = 11

def get_characters(isbn):
    uppered = isbn.upper()
    regex = re.compile('[^0-9A-Z]')
    return regex.sub('', uppered)

def has_invalid_letter(characters):
    return any(invalid_letter in characters for invalid_letter in INVALID_LETTERS)

def has_check_character(characters):
    return CHECK_CHARACTER in characters

def check_character_invalid(characters):
    return characters[len(characters) - 1] != CHECK_CHARACTER

def is_invalid(characters):
    if len(characters) != ISBN10_CHARACTER_LENGTH:
        return True

    if has_invalid_letter(characters):
        return True

    if has_check_character(characters) and check_character_invalid(characters):
        return True

    return False

def get_character_value(character):
    if character == CHECK_CHARACTER:
        return CHECK_CHARACTER_VALUE
    return int(character)

def get_checksum(characters):
    checksum = 0
    for index, character in enumerate(characters):
        character_value = get_character_value(character)
        multiplier = MULTIPLIER_BASE - index
        result = multiplier * character_value
        checksum += result
    return checksum

def is_valid(isbn):
    characters = get_characters(isbn)
    if is_invalid(characters):
        return False
    checksum = get_checksum(characters)
    return checksum % CHECKCUM_MOD_VALUE == 0
        