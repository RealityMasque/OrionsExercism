import re

def is_pangram(sentence):
    lowered = sentence.lower()
    regex = re.compile('[^a-z]')
    letters = regex.sub('', lowered)
    characters = set(letters)
    character_count = len(characters)
    return character_count == 26
