import { Injectable } from "@nestjs/common";
import { PrismaService } from "../prisma/prisma.service";
import { SkillServiceBase } from "./base/skill.service.base";

@Injectable()
export class SkillService extends SkillServiceBase {
  constructor(protected readonly prisma: PrismaService) {
    super(prisma);
  }
}
