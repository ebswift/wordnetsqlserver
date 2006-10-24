select word.lemma,synset.synsetid,vnframeref.frameid,vnexampledef.example,vnframedef.syntax,vnframedef.semantics from word
left join sense on word.wordid=sense.wordid
left join synset on sense.synsetid=synset.synsetid
left join vnframeref on synset.synsetid=vnframeref.synsetid and word.wordid=vnframeref.wordid
left join vnframedef on vnframeref.frameid=vnframedef.frameid
left join vnexampleref on vnframeref.frameid=vnexampleref.frameid
left join vnexampledef on vnexampleref.exampleid=vnexampledef.exampleid
where synset.pos='v' and word.lemma='guide'