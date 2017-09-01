package com.ankamagames.dofus.network.types.version
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class VersionExtended extends Version implements INetworkType
   {
      
      public static const protocolId:uint = 393;
       
      
      public var install:uint = 0;
      
      public var technology:uint = 0;
      
      public function VersionExtended()
      {
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 393;
      }
      
      public function initVersionExtended(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:uint = 0, param7:uint = 0, param8:uint = 0) : VersionExtended
      {
         super.initVersion(param1,param2,param3,param4,param5,param6);
         this.install = param7;
         this.technology = param8;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.install = 0;
         this.technology = 0;
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_VersionExtended(param1);
      }
      
      public function serializeAs_VersionExtended(param1:ICustomDataOutput) : void
      {
         super.serializeAs_Version(param1);
         param1.writeByte(this.install);
         param1.writeByte(this.technology);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_VersionExtended(param1);
      }
      
      public function deserializeAs_VersionExtended(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._installFunc(param1);
         this._technologyFunc(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_VersionExtended(param1);
      }
      
      public function deserializeAsyncAs_VersionExtended(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._installFunc);
         param1.addChild(this._technologyFunc);
      }
      
      private function _installFunc(param1:ICustomDataInput) : void
      {
         this.install = param1.readByte();
         if(this.install < 0)
         {
            throw new Error("Forbidden value (" + this.install + ") on element of VersionExtended.install.");
         }
      }
      
      private function _technologyFunc(param1:ICustomDataInput) : void
      {
         this.technology = param1.readByte();
         if(this.technology < 0)
         {
            throw new Error("Forbidden value (" + this.technology + ") on element of VersionExtended.technology.");
         }
      }
   }
}
