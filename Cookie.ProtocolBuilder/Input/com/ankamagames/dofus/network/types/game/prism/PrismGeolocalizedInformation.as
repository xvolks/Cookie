package com.ankamagames.dofus.network.types.game.prism
{
   import com.ankamagames.dofus.network.ProtocolTypeManager;
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   [Trusted]
   public class PrismGeolocalizedInformation extends PrismSubareaEmptyInfo implements INetworkType
   {
      
      public static const protocolId:uint = 434;
       
      
      public var worldX:int = 0;
      
      public var worldY:int = 0;
      
      public var mapId:int = 0;
      
      public var prism:PrismInformation;
      
      private var _prismtree:FuncTree;
      
      public function PrismGeolocalizedInformation()
      {
         this.prism = new PrismInformation();
         super();
      }
      
      override public function getTypeId() : uint
      {
         return 434;
      }
      
      public function initPrismGeolocalizedInformation(param1:uint = 0, param2:uint = 0, param3:int = 0, param4:int = 0, param5:int = 0, param6:PrismInformation = null) : PrismGeolocalizedInformation
      {
         super.initPrismSubareaEmptyInfo(param1,param2);
         this.worldX = param3;
         this.worldY = param4;
         this.mapId = param5;
         this.prism = param6;
         return this;
      }
      
      override public function reset() : void
      {
         super.reset();
         this.worldX = 0;
         this.worldY = 0;
         this.mapId = 0;
         this.prism = new PrismInformation();
      }
      
      override public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_PrismGeolocalizedInformation(param1);
      }
      
      public function serializeAs_PrismGeolocalizedInformation(param1:ICustomDataOutput) : void
      {
         super.serializeAs_PrismSubareaEmptyInfo(param1);
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
         param1.writeShort(this.prism.getTypeId());
         this.prism.serialize(param1);
      }
      
      override public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_PrismGeolocalizedInformation(param1);
      }
      
      public function deserializeAs_PrismGeolocalizedInformation(param1:ICustomDataInput) : void
      {
         super.deserialize(param1);
         this._worldXFunc(param1);
         this._worldYFunc(param1);
         this._mapIdFunc(param1);
         var _loc2_:uint = param1.readUnsignedShort();
         this.prism = ProtocolTypeManager.getInstance(PrismInformation,_loc2_);
         this.prism.deserialize(param1);
      }
      
      override public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_PrismGeolocalizedInformation(param1);
      }
      
      public function deserializeAsyncAs_PrismGeolocalizedInformation(param1:FuncTree) : void
      {
         super.deserializeAsync(param1);
         param1.addChild(this._worldXFunc);
         param1.addChild(this._worldYFunc);
         param1.addChild(this._mapIdFunc);
         this._prismtree = param1.addChild(this._prismtreeFunc);
      }
      
      private function _worldXFunc(param1:ICustomDataInput) : void
      {
         this.worldX = param1.readShort();
         if(this.worldX < -255 || this.worldX > 255)
         {
            throw new Error("Forbidden value (" + this.worldX + ") on element of PrismGeolocalizedInformation.worldX.");
         }
      }
      
      private function _worldYFunc(param1:ICustomDataInput) : void
      {
         this.worldY = param1.readShort();
         if(this.worldY < -255 || this.worldY > 255)
         {
            throw new Error("Forbidden value (" + this.worldY + ") on element of PrismGeolocalizedInformation.worldY.");
         }
      }
      
      private function _mapIdFunc(param1:ICustomDataInput) : void
      {
         this.mapId = param1.readInt();
      }
      
      private function _prismtreeFunc(param1:ICustomDataInput) : void
      {
         var _loc2_:uint = param1.readUnsignedShort();
         this.prism = ProtocolTypeManager.getInstance(PrismInformation,_loc2_);
         this.prism.deserializeAsync(this._prismtree);
      }
   }
}
