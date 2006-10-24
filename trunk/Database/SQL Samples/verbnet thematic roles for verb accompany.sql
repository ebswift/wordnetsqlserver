select word.lemma,synset.synsetid,vnroledef.type,vnselrestrref.logic,vnselrestrdef.value_,vnselrestrdef.type from word
left join sense on word.wordid=sense.wordid
left join synset on sense.synsetid=synset.synsetid
left join vnroleref on synset.synsetid=vnroleref.synsetid and word.wordid=vnroleref.wordid
left join vnroledef on vnroleref.roleid=vnroledef.roleid
left join vnselrestrref on vnroleref.selrestrsetid=vnselrestrref.selrestrsetid
left join vnselrestrdef on vnselrestrref.selrestrid=vnselrestrdef.selrestrid
where synset.pos='v' and word.lemma='accompany'