select word.lemma, synset.pos, synset.definition from word
left join sense on word.wordid=sense.wordid
left join synset on sense.synsetid=synset.synsetid
where word.lemma='light'
order by synset.pos
