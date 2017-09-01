package com.ankamagames.dofus.network.types.game.context.roleplay
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class MonsterInGroupLightInformations implements INetworkType
   {
      
      public static const protocolId:uint = 395;
       
      
      public var creatureGenericId:int = 0;
      
      public var grade:uint = 0;
      
      public function MonsterInGroupLightInformations()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 395;
      }
      
      public function initMonsterInGroupLightInformations(param1:int = 0, param2:uint = 0) : MonsterInGroupLightInformations
      {
         this.creatureGenericId = param1;
         this.grade = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.creatureGenericId = 0;
         this.grade = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_MonsterInGroupLightInformations(param1);
      }
      
      public function serializeAs_MonsterInGroupLightInformations(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.creatureGenericId);
         if(this.grade < 0)
         {
            throw new Error("Forbidden value (" + this.grade + ") on element grade.");
         }
         param1.writeByte(this.grade);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_MonsterInGroupLightInformations(param1);
      }
      
      public function deserializeAs_MonsterInGroupLightInformations(param1:ICustomDataInput) : void
      {
         this._creatureGenericIdFunc(param1);
         this._gradeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_MonsterInGroupLightInformations(param1);
      }
      
      public function deserializeAsyncAs_MonsterInGroupLightInformations(param1:FuncTree) : void
      {
         param1.addChild(this._creatureGenericIdFunc);
         param1.addChild(this._gradeFunc);
      }
      
      private function _creatureGenericIdFunc(param1:ICustomDataInput) : void
      {
         this.creatureGenericId = param1.readInt();
      }
      
      private function _gradeFunc(param1:ICustomDataInput) : void
      {
         this.grade = param1.readByte();
         if(this.grade < 0)
         {
            throw new Error("Forbidden value (" + this.grade + ") on element of MonsterInGroupLightInformations.grade.");
         }
      }
   }
}
