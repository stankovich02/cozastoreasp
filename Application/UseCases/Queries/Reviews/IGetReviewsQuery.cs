﻿using Application.DTO;
using Application.DTO.Reviews;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Queries.Reviews
{
    public interface IGetReviewsQuery: IQuery<PagedResponse<ReviewDTO>,SearchReview>
    {
    }
}
