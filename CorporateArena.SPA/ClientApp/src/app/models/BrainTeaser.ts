import { BrainTeaserWinner } from './BrainTeaserWinner';
import { BrainTeaserAnswer } from './BrainTeaserAnswer';

class BrainTeaser {
  id: number;
  riddle: string;
  brainTeaserAnswers: BrainTeaserAnswer[];
  brainTeaserWinners: BrainTeaserWinner[];
  userCreated: number;
  dateCreated: Date;
  dateModified: Date;
  correctAnswer: string;
  gift: string;
  isApproved: boolean;
  isDeleted: boolean;
}

export default BrainTeaser;
