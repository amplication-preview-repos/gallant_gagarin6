import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { StaffAgencyServiceBase } from "./base/staffAgency.service.base";

@Injectable()
export class StaffAgencyService extends StaffAgencyServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
