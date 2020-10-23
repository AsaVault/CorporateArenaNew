import { Comment } from './';
class Blog {
  id: number;
  title: string;
  slug: string;
  content: string;
  dateCreated: Date;
  publishedAt: Date;
  comments: Comment[];
}

export default Blog;
