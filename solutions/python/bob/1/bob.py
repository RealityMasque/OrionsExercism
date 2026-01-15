import re

def is_whitespace(to_check):
    cleaned = ''.join(to_check.split())
    return cleaned == ''

def is_question(to_check):
    stripped = to_check.strip()
    return stripped[len(stripped) - 1] == '?'

def is_yelled(to_check):
    has_lower_letters = re.search('[a-z]', to_check) is not None
    has_upper_letters = re.search('[A-Z]', to_check) is not None

    if not has_lower_letters and not has_upper_letters:
        return False

    if not has_lower_letters and has_upper_letters:
        return True

    return False

def response(hey_bob):
    if is_whitespace(hey_bob):
        return "Fine. Be that way!"
    
    if is_question(hey_bob) and is_yelled(hey_bob):
        return "Calm down, I know what I'm doing!"
    
    if is_question(hey_bob):
        return "Sure."
    
    if is_yelled(hey_bob):
        return "Whoa, chill out!"

    return "Whatever."
    