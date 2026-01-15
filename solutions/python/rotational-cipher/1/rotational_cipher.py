import string

def rotate(text, key):
    lowered = text.lower()
    rotated_text = ''
    for index, character in enumerate(lowered):
        if character.isalpha():
            plain_index = string.ascii_lowercase.index(character)
            rotated_index = plain_index + key
            rotated_index = rotated_index % 26
            rotated_character = string.ascii_lowercase[rotated_index]
            if text[index].isupper():
                rotated_character = rotated_character.upper()
            rotated_text = rotated_text + rotated_character
        else:
            rotated_text = rotated_text + character
    return rotated_text