import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { JobServiceBase } from "./base/job.service.base";

@Injectable()
export class JobService extends JobServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
