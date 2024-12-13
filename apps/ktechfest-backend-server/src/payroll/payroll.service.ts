import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { PayrollServiceBase } from "./base/payroll.service.base";

@Injectable()
export class PayrollService extends PayrollServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
