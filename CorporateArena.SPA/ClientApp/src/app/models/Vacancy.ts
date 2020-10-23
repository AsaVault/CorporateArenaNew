import JobCategory from './JobCategory';
import JobType from './JobType';

class Vacancy {
  id: number;
  title: string;
  description: string;
  location: string;
  employee: string;
  jobCategory: JobCategory;
  jobType: JobType;
  createdAt: Date;
}

export default Vacancy;
