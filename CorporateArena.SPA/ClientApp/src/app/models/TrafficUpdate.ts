import { CommentRequestTrafficUpdate } from './CommentRequestTrafficUpdate';
import { Comment } from '.';

type TrafficUpdate = {
  id: number;
  title: string;
  description: string;
  slug: string;
  dateCreated: Date;
  trafficUpdateComments: CommentRequestTrafficUpdate[];
};

export default TrafficUpdate;
