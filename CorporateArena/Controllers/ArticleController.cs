using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorporateArena.Domain;
using CorporateArena.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorporateArena.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _service;

        public ArticleController(IArticleService service)
        {
            _service = service;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        ///[Authorize]
        //[AuthorizePermission(Permissions = Permission.CreateArticle)]
        [HttpPost("CreateArticle")]
        public async Task<IActionResult> CreateArticle(Article data)
        {
            var result = await _service.SaveArticleAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetApprovedArticles")]
        public async Task<IActionResult> GetApprovedArticles()
        {
            var result = await _service.getApprovedArticlesAsync();
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetArticles")]
        public async Task<IActionResult> GetArticles()
        {
            var result = await _service.getArticlesAsync();
            return Ok(result);
        }

        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.ReadArticle)]
        [HttpGet("GetArticle/{ID}")]
        public async Task<IActionResult> GetArticle(int ID)
        {
            var result = await _service.GetArticleWithCommentsAsync(ID);
            return Ok(result);
        }

        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.ReadArticle)]
        [HttpGet("GetApprovedArticle/{ID}")]
        public async Task<IActionResult> GetApprovedArticle(int ID)
        {
            var result = await _service.GetApprovedArticleWithCommentsAsync(ID);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.LikeArticle)]
        [HttpPost("LikeArticle")]
        public async Task<IActionResult> LikeArticle(ArticleLikeViewModel data)
        {
            var result = await _service.LikeArticleAsync(data.UserID, data.ArticleID);
            return Ok(result);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.LikeArticle)]
        [HttpPost("ApproveArticle")]
        public async Task<IActionResult> ApproveArticle(ArticleLikeViewModel data)
        {
            var result = await _service.ApproveArticleAsync(data.UserID, data.ArticleID);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.CommentArticle)]
        [HttpPost("CommentOnArticle")]
        public async Task<IActionResult> CommentOnArticle(ArticleComment data)
        {
            var result = await _service.SubmitCommentAsync(data);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.LikeArticle)]
        [HttpPost("LikeComment")]
        public async Task<IActionResult> LikeComment(CommentLikeViewModel data)
        {
            var result = await _service.LikeCommentAsync(data.UserID, data.ArticleID, data.CommentID);
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        //[Authorize]
        //[AuthorizePermission(Permissions = Permission.DeleteArticle)]
        [HttpDelete("DeleteArticle/{UserID}/{ArticleID}")]
        public async Task<IActionResult> DeleteArticle(int UserID,int ArticleID)
        {
            var result = await _service.DeleteArticleAsync(ArticleID,UserID);
            return Ok(result);
        }
    }
}
