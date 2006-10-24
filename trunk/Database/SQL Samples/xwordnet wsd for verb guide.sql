select word.lemma,synset.synsetid,xwnwsd.wsd from word
left join sense on word.wordid=sense.wordid
left join synset on sense.synsetid=synset.synsetid
left join xwnwsd on synset.synsetid=xwnwsd.synsetid
where synset.pos='v' and word.lemma='guide'