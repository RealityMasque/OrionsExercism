def to_rna(dna_strand):
    rna = ''
    for dna in dna_strand:
        if dna == 'G':
            rna = rna + 'C'
        elif dna == 'C':
            rna = rna + 'G'
        elif dna == 'T':
            rna = rna + 'A'
        elif dna == 'A':
            rna = rna + 'U'
    return rna
