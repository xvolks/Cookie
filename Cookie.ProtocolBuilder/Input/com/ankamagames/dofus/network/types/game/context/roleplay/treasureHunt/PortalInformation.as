package com.ankamagames.dofus.network.types.game.context.roleplay.treasureHunt
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class PortalInformation implements INetworkType
   {
      
      public static const protocolId:uint = 466;
       
      
      public var portalId:int = 0;
      
      public var areaId:int = 0;
      
      public function PortalInformation()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 466;
      }
      
      public function initPortalInformation(param1:int = 0, param2:int = 0) : PortalInformation
      {
         this.portalId = param1;
         this.areaId = param2;
         return this;
      }
      
      public function reset() : void
      {
         this.portalId = 0;
         this.areaId = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PortalInformation(param1);
      }
      
      public function serializeAs_PortalInformation(param1:ICustomDataOutput) : void
      {
         param1.writeInt(this.portalId);
         param1.writeShort(this.areaId);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PortalInformation(param1);
      }
      
      public function deserializeAs_PortalInformation(param1:ICustomDataInput) : void
      {
         this._portalIdFunc(param1);
         this._areaIdFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PortalInformation(param1);
      }
      
      public function deserializeAsyncAs_PortalInformation(param1:FuncTree) : void
      {
         param1.addChild(this._portalIdFunc);
         param1.addChild(this._areaIdFunc);
      }
      
      private function _portalIdFunc(param1:ICustomDataInput) : void
      {
         this.portalId = param1.readInt();
      }
      
      private function _areaIdFunc(param1:ICustomDataInput) : void
      {
         this.areaId = param1.readShort();
      }
   }
}
