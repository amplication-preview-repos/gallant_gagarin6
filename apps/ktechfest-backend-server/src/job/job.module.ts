import { Module } from "@nestjs/common";
import { JobModuleBase } from "./base/job.module.base";
import { JobService } from "./job.service";
import { JobController } from "./job.controller";

@Module({
  imports: [JobModuleBase],
  controllers: [JobController],
  providers: [JobService],
  exports: [JobService],
})
export class JobModule {}
