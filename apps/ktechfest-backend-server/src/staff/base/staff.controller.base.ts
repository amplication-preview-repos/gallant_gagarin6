/*
------------------------------------------------------------------------------ 
This code was generated by Amplication. 
 
Changes to this file will be lost if the code is regenerated. 

There are other ways to to customize your code, see this doc to learn more
https://docs.amplication.com/how-to/custom-code

------------------------------------------------------------------------------
  */
import * as common from "@nestjs/common";
import * as swagger from "@nestjs/swagger";
import { isRecordNotFoundError } from "../../prisma.util";
import * as errors from "../../errors";
import { Request } from "express";
import { plainToClass } from "class-transformer";
import { ApiNestedQuery } from "../../decorators/api-nested-query.decorator";
import { StaffService } from "../staff.service";
import { StaffCreateInput } from "./StaffCreateInput";
import { Staff } from "./Staff";
import { StaffFindManyArgs } from "./StaffFindManyArgs";
import { StaffWhereUniqueInput } from "./StaffWhereUniqueInput";
import { StaffUpdateInput } from "./StaffUpdateInput";
import { PayrollFindManyArgs } from "../../payroll/base/PayrollFindManyArgs";
import { Payroll } from "../../payroll/base/Payroll";
import { PayrollWhereUniqueInput } from "../../payroll/base/PayrollWhereUniqueInput";
import { SkillFindManyArgs } from "../../skill/base/SkillFindManyArgs";
import { Skill } from "../../skill/base/Skill";
import { SkillWhereUniqueInput } from "../../skill/base/SkillWhereUniqueInput";

export class StaffControllerBase {
  constructor(protected readonly service: StaffService) {}
  @common.Post()
  @swagger.ApiCreatedResponse({ type: Staff })
  @swagger.ApiBody({
    type: StaffCreateInput,
  })
  async createStaff(@common.Body() data: StaffCreateInput): Promise<Staff> {
    return await this.service.createStaff({
      data: {
        ...data,

        staffAgency: data.staffAgency
          ? {
              connect: data.staffAgency,
            }
          : undefined,

        user: data.user
          ? {
              connect: data.user,
            }
          : undefined,
      },
      select: {
        availability: true,
        createdAt: true,
        cv: true,
        email: true,
        id: true,
        name: true,

        staffAgency: {
          select: {
            id: true,
          },
        },

        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
  }

  @common.Get()
  @swagger.ApiOkResponse({ type: [Staff] })
  @ApiNestedQuery(StaffFindManyArgs)
  async staffItems(@common.Req() request: Request): Promise<Staff[]> {
    const args = plainToClass(StaffFindManyArgs, request.query);
    return this.service.staffItems({
      ...args,
      select: {
        availability: true,
        createdAt: true,
        cv: true,
        email: true,
        id: true,
        name: true,

        staffAgency: {
          select: {
            id: true,
          },
        },

        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
  }

  @common.Get("/:id")
  @swagger.ApiOkResponse({ type: Staff })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async staff(
    @common.Param() params: StaffWhereUniqueInput
  ): Promise<Staff | null> {
    const result = await this.service.staff({
      where: params,
      select: {
        availability: true,
        createdAt: true,
        cv: true,
        email: true,
        id: true,
        name: true,

        staffAgency: {
          select: {
            id: true,
          },
        },

        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
    if (result === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return result;
  }

  @common.Patch("/:id")
  @swagger.ApiOkResponse({ type: Staff })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  @swagger.ApiBody({
    type: StaffUpdateInput,
  })
  async updateStaff(
    @common.Param() params: StaffWhereUniqueInput,
    @common.Body() data: StaffUpdateInput
  ): Promise<Staff | null> {
    try {
      return await this.service.updateStaff({
        where: params,
        data: {
          ...data,

          staffAgency: data.staffAgency
            ? {
                connect: data.staffAgency,
              }
            : undefined,

          user: data.user
            ? {
                connect: data.user,
              }
            : undefined,
        },
        select: {
          availability: true,
          createdAt: true,
          cv: true,
          email: true,
          id: true,
          name: true,

          staffAgency: {
            select: {
              id: true,
            },
          },

          updatedAt: true,

          user: {
            select: {
              id: true,
            },
          },
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }

  @common.Delete("/:id")
  @swagger.ApiOkResponse({ type: Staff })
  @swagger.ApiNotFoundResponse({ type: errors.NotFoundException })
  async deleteStaff(
    @common.Param() params: StaffWhereUniqueInput
  ): Promise<Staff | null> {
    try {
      return await this.service.deleteStaff({
        where: params,
        select: {
          availability: true,
          createdAt: true,
          cv: true,
          email: true,
          id: true,
          name: true,

          staffAgency: {
            select: {
              id: true,
            },
          },

          updatedAt: true,

          user: {
            select: {
              id: true,
            },
          },
        },
      });
    } catch (error) {
      if (isRecordNotFoundError(error)) {
        throw new errors.NotFoundException(
          `No resource was found for ${JSON.stringify(params)}`
        );
      }
      throw error;
    }
  }

  @common.Get("/:id/payrolls")
  @ApiNestedQuery(PayrollFindManyArgs)
  async findPayrolls(
    @common.Req() request: Request,
    @common.Param() params: StaffWhereUniqueInput
  ): Promise<Payroll[]> {
    const query = plainToClass(PayrollFindManyArgs, request.query);
    const results = await this.service.findPayrolls(params.id, {
      ...query,
      select: {
        agency: {
          select: {
            id: true,
          },
        },

        createdAt: true,
        id: true,
        payDate: true,
        salaryAmount: true,

        staff: {
          select: {
            id: true,
          },
        },

        status: true,
        updatedAt: true,
      },
    });
    if (results === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return results;
  }

  @common.Post("/:id/payrolls")
  async connectPayrolls(
    @common.Param() params: StaffWhereUniqueInput,
    @common.Body() body: PayrollWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      payrolls: {
        connect: body,
      },
    };
    await this.service.updateStaff({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Patch("/:id/payrolls")
  async updatePayrolls(
    @common.Param() params: StaffWhereUniqueInput,
    @common.Body() body: PayrollWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      payrolls: {
        set: body,
      },
    };
    await this.service.updateStaff({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Delete("/:id/payrolls")
  async disconnectPayrolls(
    @common.Param() params: StaffWhereUniqueInput,
    @common.Body() body: PayrollWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      payrolls: {
        disconnect: body,
      },
    };
    await this.service.updateStaff({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Get("/:id/skills")
  @ApiNestedQuery(SkillFindManyArgs)
  async findSkills(
    @common.Req() request: Request,
    @common.Param() params: StaffWhereUniqueInput
  ): Promise<Skill[]> {
    const query = plainToClass(SkillFindManyArgs, request.query);
    const results = await this.service.findSkills(params.id, {
      ...query,
      select: {
        createdAt: true,
        description: true,
        id: true,

        jobs: {
          select: {
            id: true,
          },
        },

        name: true,

        staff: {
          select: {
            id: true,
          },
        },

        updatedAt: true,

        user: {
          select: {
            id: true,
          },
        },
      },
    });
    if (results === null) {
      throw new errors.NotFoundException(
        `No resource was found for ${JSON.stringify(params)}`
      );
    }
    return results;
  }

  @common.Post("/:id/skills")
  async connectSkills(
    @common.Param() params: StaffWhereUniqueInput,
    @common.Body() body: SkillWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      skills: {
        connect: body,
      },
    };
    await this.service.updateStaff({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Patch("/:id/skills")
  async updateSkills(
    @common.Param() params: StaffWhereUniqueInput,
    @common.Body() body: SkillWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      skills: {
        set: body,
      },
    };
    await this.service.updateStaff({
      where: params,
      data,
      select: { id: true },
    });
  }

  @common.Delete("/:id/skills")
  async disconnectSkills(
    @common.Param() params: StaffWhereUniqueInput,
    @common.Body() body: SkillWhereUniqueInput[]
  ): Promise<void> {
    const data = {
      skills: {
        disconnect: body,
      },
    };
    await this.service.updateStaff({
      where: params,
      data,
      select: { id: true },
    });
  }
}