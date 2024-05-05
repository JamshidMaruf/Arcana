﻿using Arcana.Domain.Commons;
using Arcana.Domain.Entities.Quizzes;
using Arcana.Domain.Entities.Students;

namespace Arcana.Domain.Entities.QuizApplications;

public class QuizApplication : Auditable
{
    public long StudentId { get; set; }
    public long QuizId { get; set; }
    
    public Student Student { get; set; }
    public Quiz Quiz { get; set; }
}
