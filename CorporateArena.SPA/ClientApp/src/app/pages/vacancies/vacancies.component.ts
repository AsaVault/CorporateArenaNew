import { Component, OnInit } from '@angular/core';
import { Vacancy, JobCategory, JobType } from 'src/app/models';
import { VacancyService } from '../../services/vacancy.service';

@Component({
  selector: 'app-vacancies',
  templateUrl: './vacancies.component.html',
  styleUrls: ['./vacancies.component.scss'],
})
export class VacanciesComponent implements OnInit {
  vacancies: Vacancy[];
  categories: JobCategory[];
  jobTypes: JobType[];

  constructor(private service: VacancyService) {}

  ngOnInit(): void {
    this.service.getVacancies().subscribe((vacancies) => {
      this.vacancies = vacancies;
    });

    this.service.getJobCategories().subscribe((categories) => {
      this.categories = categories;
    });

    this.service.getJobTypes().subscribe((jobTypes) => {
      this.jobTypes = jobTypes;

      console.log(jobTypes);
    });
  }
}
