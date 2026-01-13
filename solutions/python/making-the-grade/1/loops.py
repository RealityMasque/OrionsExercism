"""Functions for organizing and calculating student exam scores."""

FAILING_THRESHOLD = 40
GRADE_BUCKET_COUNT = 4

def round_scores(student_scores):
    """Round all provided student scores.

    :param student_scores: list - float or int of student exam scores.
    :return: list - student scores *rounded* to nearest integer value.
    """
    rounded_scores = []
    for score in student_scores:
        rounded_scores.append(round(score))
        
    return rounded_scores


def count_failed_students(student_scores):
    """Count the number of failing students out of the group provided.

    :param student_scores: list - containing int student scores.
    :return: int - count of student scores at or below 40.
    """
    count = 0
    for score in student_scores:
        if score <= 40:
            count += 1
    return count


def above_threshold(student_scores, threshold):
    """Determine how many of the provided student scores were 'the best' based on the provided threshold.

    :param student_scores: list - of integer scores.
    :param threshold: int - threshold to cross to be the "best" score.
    :return: list - of integer scores that are at or above the "best" threshold.
    """
    best = []
    for score in student_scores:
        if score >= threshold:
            best.append(score)
    return best


def letter_grades(highest):
    """Create a list of grade thresholds based on the provided highest grade.

    :param highest: int - value of highest exam score.
    :return: list - of lower threshold scores for each D-A letter grade interval.
            For example, where the highest score is 100, and failing is <= 40,
            The result would be [41, 56, 71, 86]:

            41 <= "D" <= 55
            56 <= "C" <= 70
            71 <= "B" <= 85
            86 <= "A" <= 100
    """
    score_range = highest - FAILING_THRESHOLD
    score_interval = int(score_range / GRADE_BUCKET_COUNT)
    lowest_thresholds = []
    lowest_thresholds.append(FAILING_THRESHOLD + 1)
    for number in range(1, GRADE_BUCKET_COUNT):
        lowest_thresholds.append(lowest_thresholds[number - 1] + score_interval)
    return lowest_thresholds


def student_ranking(student_scores, student_names):
    """Organize the student's rank, name, and grade information in descending order.

    :param student_scores: list - of scores in descending order.
    :param student_names: list - of string names by exam score in descending order.
    :return: list - of strings in format ["<rank>. <student name>: <score>"].
    """
    rankings = []
    for index, score in enumerate(student_scores):
        ranking = f'{index + 1}. {student_names[index]}: {score}'
        rankings.append(ranking)
    return rankings


def perfect_score(student_info):
    """Create a list that contains the name and grade of the first student to make a perfect score on the exam.

    :param student_info: list - of [<student name>, <score>] lists.
    :return: list - first `[<student name>, 100]` or `[]` if no student score of 100 is found.
    """
    perfects = []
    for info in student_info:
        if info[1] == 100:
            perfects.append(info)
            break
            
    if len(perfects) == 0:
        return perfects

    return perfects[0]
