select wa.lemma + ' -- ' + sy1.definition, wb.lemma + ' -- ' + sy2.definition
from word w1
left join sense se1 on w1.wordid = se1.wordid
left join synset sy1 on se1.synsetid = sy1.synsetid
left join semlinkref on sy1.synsetid = semlinkref.synset1id
left join synset sy2 on semlinkref.synset2id = sy2.synsetid
left join sense se2 on sy2.synsetid = se2.synsetid
left join word wb on se2.wordid = wb.wordid
left join sense se3 on sy1.synsetid = se3.synsetid
left join word wa on se3.wordid = wa.wordid
where w1.lemma = 'horse'
and sy1.pos = 'n'
and semlinkref.linkid = 1
order by se1.rank, wa.wordid, wb.wordid asc
