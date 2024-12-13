import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { JobService } from "./job.service";
import { JobControllerBase } from "./base/job.controller.base";

@swagger.ApiTags("jobs")
@common.Controller("jobs")
export class JobController extends JobControllerBase {
  constructor(protected readonly service: JobService) {
    super(service);
  }
}
