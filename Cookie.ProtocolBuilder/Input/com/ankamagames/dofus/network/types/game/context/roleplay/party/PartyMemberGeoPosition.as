package com.ankamagames.dofus.network.types.game.context.roleplay.party
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class PartyMemberGeoPosition implements INetworkType
   {
      
      public static const protocolId:uint = 378;
       
      
      public var memberId:uint = 0;
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public var mapId:int = 0;
      
      public var subAreaId:uint = 0;
      
      public function PartyMemberGeoPosition()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 378;
      }
      
      public function initPartyMemberGeoPosition(param1:uint = 0, param2:int = 0, param3:int = 0, param4:int = 0, param5:uint = 0) : PartyMemberGeoPosition
      {
         this.memberId = param1;
         this.worldX = param2;
         this.worldY = param3;
         this.mapId = param4;
         this.subAreaId = param5;
         return this;
      }
      
      public function reset() : void
      {
         this.memberId = 0;
         this.worldX = 0;
         this.worldY = 0;
         this.mapId = 0;
         this.subAreaId = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PartyMemberGeoPosition(param1);
      }
      
      public function serializeAs_PartyMemberGeoPosition(param1:ICustomDataOutput) : void
      {
         if(this.memberId < 0)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element memberId.");
         }
         param1.writeInt(this.memberId);
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element worldX.");
         }
         param1.writeShort(this.worldX);
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element worldY.");
         }
         param1.writeShort(this.worldY);
         param1.writeInt(this.mapId);
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element subAreaId.");
         }
         param1.writeVarShort(this.subAreaId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PartyMemberGeoPosition(param1);
      }
      
      public function deserializeAs_PartyMemberGeoPosition(param1:ICustomDataInput) : void
      {
         this._memberIdFunc(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
         this._mapIdFunc(param1);
         this._subAreaIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PartyMemberGeoPosition(param1);
      }
      
      public function deserializeAsyncAs_PartyMemberGeoPosition(param1:FuncTree) : void
      {
         param1.addChild(this._memberIdFunc);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
         param1.addChild(this._mapIdFunc);
         param1.addChild(this._subAreaIdFunc);
      }
      
      private function _memberIdFunc(param1:ICustomDataInput) : void
      {
         this.memberId = param1.readInt();
         if(this.memberId < 0)
         {
            throw new Error("Forbidden value (" + this.memberId + ") on element of PartyMemberGeoPosition.memberId.");
         }
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of PartyMemberGeoPosition.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of PartyMemberGeoPosition.worldY.");
         }
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
      }
      
      private function _subAreaIdFunc(param1:ICustomDataInput) : void
      {
         this.subAreaId = param1.readVarUhShort();
         if(this.subAreaId < 0)
         {
            throw new Error("Forbidden value (" + this.subAreaId + ") on element of PartyMemberGeoPosition.subAreaId.");
         }
      }
   }
}
