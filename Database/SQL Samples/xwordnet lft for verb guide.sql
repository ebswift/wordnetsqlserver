select word.lemma,synset.synsetid,xwnparselft.lft from word
left join sense on word.wordid=sense.wordid
left join synset on sense.synsetid=synset.synsetid
left join xwnparselft on synset.synsetid=xwnparselft.synsetid
where synset.pos='v' and word.lemma='guide'