package com.ankamagames.dofus.network.types.version
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class Version implements INetworkType
   {
      
      public static const protocolId:uint = 11;
       
      
      public var major:uint = 0;
      
      public var minor:uint = 0;
      
      public var release:uint = 0;
      
      public var revision:uint = 0;
      
      public var patch:uint = 0;
      
      public var buildType:uint = 0;
      
      public function Version()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 11;
      }
      
      public function initVersion(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0, param5:uint = 0, param6:uint = 0) : Version
      {
         this.major = param1;
         this.minor = param2;
         this.release = param3;
         this.revision = param4;
         this.patch = param5;
         this.buildType = param6;
         return this;
      }
      
      public function reset() : void
      {
         this.major = 0;
         this.minor = 0;
         this.release = 0;
         this.revision = 0;
         this.patch = 0;
         this.buildType = 0;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_Version(param1);
      }
      
      public function serializeAs_Version(param1:ICustomDataOutput) : void
      {
         if(this.major < 0)
         {
            throw new Error("Forbidden value (" + this.major + ") on element major.");
         }
         param1.writeByte(this.major);
         if(this.minor < 0)
         {
            throw new Error("Forbidden value (" + this.minor + ") on element minor.");
         }
         param1.writeByte(this.minor);
         if(this.release < 0)
         {
            throw new Error("Forbidden value (" + this.release + ") on element release.");
         }
         param1.writeByte(this.release);
         if(this.revision < 0)
         {
            throw new Error("Forbidden value (" + this.revision + ") on element revision.");
         }
         param1.writeInt(this.revision);
         if(this.patch < 0)
         {
            throw new Error("Forbidden value (" + this.patch + ") on element patch.");
         }
         param1.writeByte(this.patch);
         param1.writeByte(this.buildType);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_Version(param1);
      }
      
      public function deserializeAs_Version(param1:ICustomDataInput) : void
      {
         this._majorFunc(param1);
         this._minorFunc(param1);
         this._releaseFunc(param1);
         this._revisionFunc(param1);
         this._patchFunc(param1);
         this._buildTypeFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_Version(param1);
      }
      
      public function deserializeAsyncAs_Version(param1:FuncTree) : void
      {
         param1.addChild(this._majorFunc);
         param1.addChild(this._minorFunc);
         param1.addChild(this._releaseFunc);
         param1.addChild(this._revisionFunc);
         param1.addChild(this._patchFunc);
         param1.addChild(this._buildTypeFunc);
      }
      
      private function _majorFunc(param1:ICustomDataInput) : void
      {
         this.major = param1.readByte();
         if(this.major < 0)
         {
            throw new Error("Forbidden value (" + this.major + ") on element of Version.major.");
         }
      }
      
      private function _minorFunc(param1:ICustomDataInput) : void
      {
         this.minor = param1.readByte();
         if(this.minor < 0)
         {
            throw new Error("Forbidden value (" + this.minor + ") on element of Version.minor.");
         }
      }
      
      private function _releaseFunc(param1:ICustomDataInput) : void
      {
         this.release = param1.readByte();
         if(this.release < 0)
         {
            throw new Error("Forbidden value (" + this.release + ") on element of Version.release.");
         }
      }
      
      private function _revisionFunc(param1:ICustomDataInput) : void
      {
         this.revision = param1.readInt();
         if(this.revision < 0)
         {
            throw new Error("Forbidden value (" + this.revision + ") on element of Version.revision.");
         }
      }
      
      private function _patchFunc(param1:ICustomDataInput) : void
      {
         this.patch = param1.readByte();
         if(this.patch < 0)
         {
            throw new Error("Forbidden value (" + this.patch + ") on element of Version.patch.");
         }
      }
      
      private function _buildTypeFunc(param1:ICustomDataInput) : void
      {
         this.buildType = param1.readByte();
         if(this.buildType < 0)
         {
            throw new Error("Forbidden value (" + this.buildType + ") on element of Version.buildType.");
         }
      }
   }
}
