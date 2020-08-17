package com.ankamagames.dofus.network.types.web.krosmaster
{
   import com.ankamagames.jerakine.network.ICustomDataInput;
   import com.ankamagames.jerakine.network.ICustomDataOutput;
   import com.ankamagames.jerakine.network.INetworkType;
   import com.ankamagames.jerakine.network.utils.FuncTree;
   
   public class KrosmasterFigure implements INetworkType
   {
      
      public static const protocolId:uint = 397;
       
      
      public var uid:String = "";
      
      public var figure:uint = 0;
      
      public var pedestal:uint = 0;
      
      public var bound:Boolean = false;
      
      public function KrosmasterFigure()
      {
         super();
      }
      
      public function getTypeId() : uint
      {
         return 397;
      }
      
      public function initKrosmasterFigure(param1:String = "", param2:uint = 0, param3:uint = 0, param4:Boolean = false) : KrosmasterFigure
      {
         this.uid = param1;
         this.figure = param2;
         this.pedestal = param3;
         this.bound = param4;
         return this;
      }
      
      public function reset() : void
      {
         this.uid = "";
         this.figure = 0;
         this.pedestal = 0;
         this.bound = false;
      }
      
      public function serialize(param1:ICustomDataOutput) : void
      {
         this.serializeAs_KrosmasterFigure(param1);
      }
      
      public function serializeAs_KrosmasterFigure(param1:ICustomDataOutput) : void
      {
         param1.writeUTF(this.uid);
         if(this.figure < 0)
         {
            throw new Error("Forbidden value (" + this.figure + ") on element figure.");
         }
         param1.writeVarShort(this.figure);
         if(this.pedestal < 0)
         {
            throw new Error("Forbidden value (" + this.pedestal + ") on element pedestal.");
         }
         param1.writeVarShort(this.pedestal);
         param1.writeBoolean(this.bound);
      }
      
      public function deserialize(param1:ICustomDataInput) : void
      {
         this.deserializeAs_KrosmasterFigure(param1);
      }
      
      public function deserializeAs_KrosmasterFigure(param1:ICustomDataInput) : void
      {
         this._uidFunc(param1);
         this._figureFunc(param1);
         this._pedestalFunc(param1);
         this._boundFunc(param1);
      }
      
      public function deserializeAsync(param1:FuncTree) : void
      {
         this.deserializeAsyncAs_KrosmasterFigure(param1);
      }
      
      public function deserializeAsyncAs_KrosmasterFigure(param1:FuncTree) : void
      {
         param1.addChild(this._uidFunc);
         param1.addChild(this._figureFunc);
         param1.addChild(this._pedestalFunc);
         param1.addChild(this._boundFunc);
      }
      
      private function _uidFunc(param1:ICustomDataInput) : void
      {
         this.uid = param1.readUTF();
      }
      
      private function _figureFunc(param1:ICustomDataInput) : void
      {
         this.figure = param1.readVarUhShort();
         if(this.figure < 0)
         {
            throw new Error("Forbidden value (" + this.figure + ") on element of KrosmasterFigure.figure.");
         }
      }
      
      private function _pedestalFunc(param1:ICustomDataInput) : void
      {
         this.pedestal = param1.readVarUhShort();
         if(this.pedestal < 0)
         {
            throw new Error("Forbidden value (" + this.pedestal + ") on element of KrosmasterFigure.pedestal.");
         }
      }
      
      private function _boundFunc(param1:ICustomDataInput) : void
      {
         this.bound = param1.readBoolean();
      }
   }
}
